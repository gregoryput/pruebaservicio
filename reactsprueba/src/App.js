import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from "axios";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEdit, faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import Modal from '@mui/material/Modal';
import Typography from '@mui/material/Typography';
import { ModalFooter } from 'reactstrap';
import TextField from '@mui/material/TextField';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import NativeSelect from '@mui/material/NativeSelect';
import InputBase from '@mui/material/InputBase';

const url = "https://localhost:7298/api/Servicios"

const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 400,
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
};

class App extends Component {
  state={
    data:[],
    modalInsertar: false,
    modalEliminar: false,
    form:{
      servicioID: '',
      nombreServicio: '',
      categoriaID: '',
   
    }
  }
  
  peticionGet=()=>{
  axios.get(url).then(response=>{
    this.setState({data: response.data});
  }).catch(error=>{
    console.log(error.message);
  })
  }
  
  peticionPost=async()=>{
  delete this.state.form.servicioID;
   await axios.post(url,this.state.form).then(response=>{
      this.modalInsertar();
      this.peticionGet();
    }).catch(error=>{
      console.log(error.message);
    })
  }
  
  peticionPut=()=>{
    axios.put(url+this.state.form.servicioID, this.state.form).then(response=>{
      this.modalInsertar();
      this.peticionGet();
    })
  }
  
  peticionDelete=()=>{
    axios.delete(url+this.state.form.servicioID).then(response=>{
      this.setState({modalEliminar: false});
      this.peticionGet();
    })
  }
  
  modalInsertar=()=>{
    this.setState({modalInsertar: !this.state.modalInsertar});
  }
  
  seleccionarServicio=(servic)=>{
    this.setState({
      tipoModal: 'actualizar',
      form: {
        servicioID: servic.servicioID,
        nombreServicio: servic.nombreServicio,
        categoriaID: servic.categoriaID,
       
      }
    })
  }
  
  handleChange=async e=>{
  e.persist();
  await this.setState({
    form:{
      ...this.state.form,
      [e.target.name]: e.target.value
    }
  });
  console.log(this.state.form);
  }
  
    componentDidMount() {
      this.peticionGet();
    }
    
  
    render(){
      const {form}=this.state;
    return (
      <div className="App">
      <br /><br /><br />
      <h1>Servicios</h1>
      <Button  variant="contained" onClick={()=>{this.setState({form: null, tipoModal: 'insertar'}); this.modalInsertar(true)}}>Ingresar Servicio nuevo</Button>
    <br /><br />
    <div style={{  marginLeft: 350, height: 300, width: '50%' }}>
    <TableContainer component={Paper}>
      <Table sx={{  minWidth: 100 }} aria-label="customized table">
        <TableHead>
          <TableRow>
            <TableCell>ID</TableCell>
            <TableCell align="right">Servicio</TableCell>
            <TableCell align="right">Categoria</TableCell>
            <TableCell align="right">Accion</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {this.state.data.map((row) => (
            <TableRow
              key={row.servicioID}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.servicioID}
              </TableCell>
              <TableCell align="right">{row.nombreServicio}</TableCell>
              <TableCell align="right">{row.categoriaID}</TableCell>
              <TableCell align="right">
              <Button  variant="text" >Edit</Button>
              <Button  variant="text" color='error' >Eliminar</Button>
              </TableCell>
             
              
            </TableRow>
            
          ))}
        </TableBody>
      </Table>
    </TableContainer>
    </div>
     
    <div>
    
      <Modal 
        open={this.state.modalInsertar}
        // onClose={this.state.modalInsertar}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <Typography id="modal-modal-title" variant="h6" component="h2">
            <h3>Registra Servicio</h3>
          </Typography>
          <Typography id="modal-modal-description" sx={{ mt: 2 }}>
          
          <div>
          <br/>
          <TextField name='ServicioID'
          disabled
          id="ServicioID"
          label="ID"
          onChange={this.handleChange}
          value={form?form.servicioID: this.state.data.length+1}
        />
        <br/><br/><br/>
        <TextField name='NombreServicio'
          required
          id="NombreServicio"
          label="Nombre de Servicio"
          onChange={this.handleChange} 
          value={form?form.nombreServicio: ''}
        />
        <br/><br/><br/>
        <TextField name='CategoriaID'
          required
          id="CategoriaID"
          label="Categoria del 1 al 3 max"
          onChange={this.handleChange} 
          value={form?form.categoriaID: ''}
        />
        <br/><br/>
          </div>

          <Button  variant='contained' onClick={()=>this.peticionPost()}>Insertar</Button>
          <Button  variant='contained' style={ { marginLeft: 100 } } color='error' onClick={()=>this.modalInsertar()}>Cancelar</Button>
          </Typography>
          
          <ModalFooter>
          
          
      </ModalFooter>
        </Box>
      </Modal>
    </div>

    
    
    </div>
  
  
  
    );
  }
  }
  export default App;

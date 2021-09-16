import api from '../../Connection/API'; 
import BootstrapTable from 'react-bootstrap-table-next'; 

import CadUsuario from './CadUsuario';

import ToolkitProvider from 'react-bootstrap-table2-toolkit';

import { ButtonGroup, Modal, ModalHeader, ModalBody, Row, Col, Button } from 'reactstrap'; 

import React, { Component } from 'react';



const columns = [ 
  { dataField: 'UsuarioId'  ,  text: 'ID'}, 
  { dataField: 'Nome'       ,  text: 'ID', sort: true, headerStyle: () => { return { width: '30%', textAlign: 'center' }; }}, 
  { dataField: 'Email'      ,  text: 'ID', sort: true, headerStyle: () => { return { width: '30%', textAlign: 'center' }; }}
]

class componentName extends Component {
  constructor(props) { 
    super(props);
    this.state={ 
      usuario           : []   , 
      openModalCadastro : false,  
      openModalEdit     : false, 
      oepnModalDelete   : false
    }
    this.load           = this.load.bind(this); 
    this.openCadastro   = this.openCadastro.bind(this); 
    this.openEdit       = this.openEdit.bind(this); 
    this.openDelete     = this.openDelete.bind(this); 
  }

  componentDidMount(){ 
    this.load(); 
  }

  // Método utilizado para carregar os dados do usuário na tabela de visualização. 
  load = async () => { 
    let obj = await api.get('/usuario'); 
    this.setState({usuario: obj.data}); 
  }

  // Método utilizado para abrir ou fechar a modal de cadastro. 
  openCadastro = () => { 

  }

  // Método utilizado para abrir ou fechar a modal de edição. 
  openEdit = () => { 

  }

  // Método utilizado para abrir ou fechar a modal de exclusão. 
  openDelete = () => { 
    
  }


  render() {
    return (
      <div>

        <Modal zIndex="99999"isOpen={this.state.openModalCadastro} className={'modal-md modal-primary ' + this.props.className}>
          <ModalHeader toggle={this.openCadastro}>Usuário</ModalHeader>  
          <ModalBody>
            <CadUsuario refreshTable={this.load} onExit={this.openCadastro}/>
          </ModalBody>
        </Modal>


        <Modal zIndex="99999"isOpen={this.state.openModalEdit} className={'modal-md modal-primary ' + this.props.className}>
          <ModalHeader toggle={this.openEdit}>Usuário</ModalHeader>  
          <ModalBody>
            <CadUsuario refreshTable={this.load} onExit={this.openEdit}/>
          </ModalBody>
        </Modal>

        <ToolkitProvider keyField="UsuarioId" data={this.state.usuario} columns={columns} search bootstrap4>
        {
          props => ( 
            <div>
              <Row>
                <Col lg="12">
                  <ButtonGroup>
                    <Button outline color="primary">Cadastrar</Button>
                    <Button outline color="info">   Editar   </Button>  
                    <Button outline color="info">   Excluir  </Button> 
                  </ButtonGroup>
                </Col>
              </Row>

              <BootstrapTable {... props.baseProps} condensed striped hover /> 
            </div>
          )
        }
        </ToolkitProvider>
      </div>
    );
  }
}

export default componentName;
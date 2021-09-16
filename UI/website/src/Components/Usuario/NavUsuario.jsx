import api from '../../Connection/API'; 
import BootstrapTable from 'react-bootstrap-table-next'; 
import CadUsuario from './CadUsuario';
import paginationFactory from 'react-bootstrap-table2-paginator';
import ToolkitProvider from 'react-bootstrap-table2-toolkit';
import Relatorio from './Relatorio'

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
      usuarioDate       : []   , 
      selectedRow       : []   , 
      openModalCadastro : false,  
      openModalEdit     : false, 
      openModalDelete   : false, 
      openRelatorio     : false
    }
    this.load             = this.load.bind(this); 
    this.openCadastro     = this.openCadastro.bind(this); 
    this.openEdit         = this.openEdit.bind(this); 
    this.openDelete       = this.openDelete.bind(this); 
    this.onSelectHandle   = this.onSelectHandle.bind(this); 
    this.setOpenRelatorio = this.setOpenRelatorio.bind(this); 
  }

  componentDidMount(){ 
    this.load(); 
  }

  // Método utilizado para carregar os dados do usuário na tabela de visualização. 
  load = async () => { 
    let obj = await api.get('/usuario'); 
    this.setState({usuarioDate: obj.data}); 
  }

  // Método utilizado para abrir ou fechar a modal de cadastro. 
  openCadastro = () => { 
    this.setState({openModalCadastro: !this.state.openModalCadastro})
  }

  // Método utilizado para abrir ou fechar a modal de edição. 
  openEdit = () => { 
    this.setState({openModalEdit: !this.state.openModalEdit})
  }

  // Método utilizado para abrir ou fechar a modal de exclusão. 
  openDelete = () => { 
    this.setState({openModalDelete: !this.state.openModalDelete})
  }

  // Método utilizado para capturar os valores da linha selecionada através do parâmetro "Row".
  onSelectHandle = (Row) => { 

  }

  setOpenRelatorio = () => { 
    this.setState({openRelatorio: !this.state.openRelatorio}); 
  }


  render() {
    /*
      Esta const tem como objetivo estilizar as linhas do bootstrap table. 
      Também vai capturar os eventos de click nas linhas selecionadas. 
    */
    const selectRow = { 
      mode             : 'radio'  ,  // Aqui define o tipo de seleção sé é rádio ou check-box. 
      bgColor          : '#bbb9b9',  // Aqui define a cor de fundo da linha selecionada. ("Marcação da linha")
      clickToSelect    : true     ,  // Aqui define sé é para apresentar a seleção ou não. 
      hideSelectColumn : true     ,  // Aqui oculta a coluna que apresenta o radio ou check-box. 
      selected         : this.state.selectedRow, // Aqui adiciona o valor da linha selecionada. 
      onSelect         : this.onSelectHandle 
    }

    /* 
      Esta const será utilizada para definir quantas linhas será exibida por paginação, 
      Poderá ocultar valores como exibição de linhas por paginas através de seleção. 

      Ex: quero exibir 10 linhas, quero exibir 20 linhas etc... 
    */
    const options = {
      sizePerPage             : 6   , // Aqui é definido um tamanho fixo por página.     
      hideSizePerPage         : true, // Aqui oculta o tamanho dinâmico
      hidePageListOnlyOnePage : true
    };

    const PDFRelatorio = () => { 
      return <Relatorio openrelatorio={this.state.openRelatorio}/>;  
    }

    return (
      <div>

        <PDFRelatorio /> 

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

        <ToolkitProvider keyField="UsuarioId" data={this.state.usuarioDate} columns={columns} search bootstrap4>
        {
          props => ( 
            <div>
              <Row>
                <Col lg="12">
                  <ButtonGroup>
                    <Button outline color="success" onClick={this.openCadastro}>Cadastrar</Button>
                    <Button outline color="primary" onClick={this.openEdit}    >Editar   </Button>  
                    <Button outline color="danger"  onClick={this.openDelete}  >Excluir  </Button> 
                    <Button outline color="warning" onClick={this.setOpenRelatorio}>imprimir </Button> 
                  </ButtonGroup>
                </Col>
              </Row>
              <br/>

              <BootstrapTable {... props.baseProps} condensed striped hover selectRow={ selectRow } pagination={ paginationFactory(options) } /> 
            </div>
          )
        }
        </ToolkitProvider>
      </div>
    );
  }
}

export default componentName;
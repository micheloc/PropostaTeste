import api from '../../Connection/API'
import React, { Component } from 'react'
import { Button, Input, InputSelect } from 'reg_validate'
import { Col, FormGroup, Label, Row } from 'reactstrap'
import { ToastContainer, toast } from 'react-toastify'; 
class CadUsuario extends Component {
  constructor(props){
    super(props); 
    this.state={ 
      selectSexoId      : '', 
      usuario: { 
        UsuarioId       : '', 
        SexoId          : '',
        Nome            : '', 
        DataNascimento  : '', 
        Email           : '', 
        Senha           : '', 
        Ativo           : true, 
      },
      sexo              : []



    }


    this.formValidate = this.formValidate.bind(this); 
    this.updateValue = this.updateValue.bind(this); 
    this.onChangeSelected = this.onChangeSelected.bind(this); 
    this.onChangeRadioBtn = this.onChangeRadioBtn.bind(this); 
    this.updateRegisterDate = this.updateRegisterDate.bind(this); 
    this.registerDate     = this.registerDate.bind(this); 
  }

  componentDidMount(){ 
    this.loadSexo(); 
    if (this.props.id !== undefined)
      this.loadUpdateUsuario(); 
  }


  /*
    Método nativo do reg_validate, com a mesma função da tag <Form> do HTML. 
    O parâmetro evento recebe um valor boolean para informar se todos os dados foram preenchidos corretamente. 
  */ 
  formValidate = (evento) => { 
    if (evento  === true){
      if (this.props.id !== undefined){ 
        this.updateRegisterDate(); 
      }else{ 
        this.registerDate(); 
      }
    }
  }

  /* 
    Método utilziado para carregar os valores salvos no banco para editar o usuário cadastrado. 
  */
  loadUpdateUsuario = async () => { 
    let obj = await api.get('/usuario/', {params: {id: this.props.id}}); 
    this.setState({usuario: obj.data}, () => { 
      this.loadLabelSexo(); 
    })
  }

  // Este método carrega o valor da label do sexo para atualização.
  loadLabelSexo = async () => { 
    let obj = await api.get('/sexo/', {params: {id: this.state.usuario.SexoId}})
    this.setState({selectSexoId: obj.data.Descricao}); 
  }

  /* 
    Método utilizado para carregar uma lista de sexo. 
  */
  loadSexo  = async () => { 
    let obj = await api.get('/sexo'); 
    this.setState({sexo: obj.data}); 
  }

  /* 
    Método nativodo reg_validate, com a mesma função do evento onChange. 
    Recebendo como parâmetro o nome do campo e o valor do campo. 
  */
  updateValue = (nameCamp, value) => { 
    let obj = Object.assign({}, this.state.usuario); 
    obj[nameCamp] = value; 
    this.setState({usuario: obj}); 
  }

  /*
    Método utilizado para alterar os valores do onchange rádio button. 
  */
  onChangeRadioBtn = (evento) => { 
    var bool; 
    if (evento.target.id === "1")
    {
      bool = true;
      this.setState({usuario: {...this.state.usuario, Ativo: true}})
    }
    else {
      bool = false; 
      this.setState({usuario: {...this.state.usuario, Ativo: false}})
    }
  }

  // Function utilizada para alterar e preencher dados da Cultura.
  onChangeSelected = (e) => {
    let obj = Object.assign({}, this.state.usuario)
    obj["SexoId"] = e.value; 
    this.setState({usuario: obj}, () =>{ 
      this.setState({selectSexoId: e.label}); 
    })
  };


  /*
    Método utilizado para atualizar os dados na base de dados. 
  */
  updateRegisterDate = () => { 
    api.put("/Usuario/?id=" + this.state.usuario.UsuarioId, this.state.usuario)
    .then(resultado => {
      if (resultado.status === 200) {
        this.props.refreshTable()
        toast.success("Usuário atualizado com sucesso!", {position: toast.POSITION.BOTTOM_RIGHT})
      }
    })
    .catch(error => { toast.error("Não foi possível estabelecer uma conexãoo com o servidor", { position: toast.POSITION.BOTTOM_RIGHT }) 
    });
    this.props.onExit()
  }

  /* 
    Método utilizado para registrar os dados na base de dados.
  */
  registerDate = () => { 
    api.post("/Usuario/", this.state.usuario)
    .then(response => {
      if (response.status === 200 || response.statusText === "OK") {
        this.props.refreshTable()
        toast.success("Usuario registrado com sucesso!", { position: toast.POSITION.BOTTOM_RIGHT });
      }
    })
    .catch(error => {
       toast.error("Não foi possível registrar um novo usuário.", {
         position: toast.POSITION.BOTTOM_RIGHT, 
       });
    });
    this.props.onExit()
  }

  render() {
    return (
      <div>
        <Row>
          <Col lg="12">
            <Label>Descrição : </Label>
            <Input name="Nome" max="200" req={ true } type="text" updateValue={ this.updateValue } value={ this.state.usuario.Nome }/>
          </Col>
        </Row> 

        <Row> 
          <Col lg="4"> 
            <Label>Dt. de Nascimento : </Label>
            <Input name="DataNascimento" req={ true } type="date" updateValue={ this.updateValue } value={ this.state.usuario.DataNascimento }/>
          </Col>
          <Col lg="8">
            <Label>Email : </Label>
            <Input name="Email" max="100" req={ true } type="email" updateValue={ this.updateValue } value={ this.state.usuario.Email }/>
          </Col>
        </Row>

        <Row> 
          <Col lg="4"> 
            <Label>Sexo : </Label>            
            <InputSelect
              maxMenuHeight={190}
              updateChange={this.onChangeSelected}
              name={"sexo"}
              req={true}
              label={this.state.selectSexoId}
              value={{ label: this.state.selectSexoId, value: this.state.usuario.SexoId }}
              options={this.state.sexo.map((opt) => ({
                label: opt.Descricao,
                name: "sexo",
                value: opt.SexoId
            }))}/>
          </Col>


          <Col lg='8'> 
            <Label>Senha : </Label>
            <Input name="Senha" max="200" req={ true } type="password" updateValue={ this.updateValue } value={ this.state.usuario.Senha }/>
          </Col>
        </Row>
        <hr/>

        <Row>
          <Col lg="3">
            <Label>Usuário ativo</Label>
            <FormGroup check>
              <Label check>
              <input className="form-check-input" checked={this.state.usuario.Ativo} type="radio" name="Ativo" id="1" onClick={this.onChangeRadioBtn} onChange={()=>{}}/>{' '}
              Ativo
              </Label>
            </FormGroup>
            <FormGroup check>
              <Label check>
              <input className="form-check-input" checked={!this.state.usuario.Ativo} type="radio" name="Ativo" id="0" onClick={this.onChangeRadioBtn}  onChange={()=>{}}/>{' '}
              Inativo
              </Label>
            </FormGroup>
          </Col>
        </Row>
        <hr/> 


        <div className="float-right">
          <Row>
            <Col>
              <Button color="primary" form={this.formValidate}  value="Confirmar"/>
            </Col>
            <Col>
              <button id='cancelar' className="btn btn-danger" type="button" onClick={() => {this.props.onExit()}} > Cancelar </button>
            </Col>
          </Row>
        </div>



      </div>
    );
  }
}

export default CadUsuario;
import React, { Component } from 'react'; 
import jsPDF from 'jspdf'; 
import 'jspdf-autotable'; 



class Relatorio extends Component{ 
  constructor(props){
    super(props); 
    this.state={ }
    this.loadRelatorio = this.loadRelatorio.bind(this); 
  }

  componentDidMount(){ 
    this.loadRelatorio(); 
  }

  loadRelatorio = () => { 
    if (this.props.openrelatorio === false)
      return; 

    var doc = new jsPDF('l', 'pt', 'a4');
    doc.text(400, 40, "Teste");
    doc.setFontSize(9.5);
    doc.text(200, 70, "Nome:   "+ "1");
    doc.text(600, 70, "Path:   "+ "7");
    doc.text(200, 80, "Teste:  "+ "5");
    doc.text(200, 90, "Teste2: "+ "4");

    doc.autoPrint()
    window.open(doc.output('bloburl'), '_blank')
    this.props.onCloseRelatorio()
  }

  render() {
    return (
      <div>

      </div>
    )
  }
}

export default Relatorio
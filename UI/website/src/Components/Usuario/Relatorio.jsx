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
    doc.text(400, 40, "Teste");
    doc.setFontSize(9.5);
    doc.text(200, 70, "Nome:   "+ "1");
    doc.text(600, 70, "Path:   "+ "7");
    doc.text(200, 80, "Teste:  "+ "5");
    doc.text(200, 90, "Teste2: "+ "4");
    var res = doc.autoTableHtmlToJson(document.getElementById("tablerelatorio"));
    var resmedia = doc.autoTableHtmlToJson(document.getElementById("tablerelatoriomedia"));

    doc.autoTable ( {
      head: [ 
        [{content: 'RESULTADO DA ANÁLISE DE SOLO',colSpan: 17}],
        [ { content: '',colSpan: 1 },
          { content: 'Relações',colSpan: 4 }
          { content: 'Participação na CTC %',colSpan: 4 }
        ]
      ]
    })


    doc.autoPrint()
    window.open(doc.output('bloburl'), '_blank')
  }

  render() {
    return (
      <div>

      </div>
    )
  }
}
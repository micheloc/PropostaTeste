import React, { Component } from 'react';
import NavUsuario from './NavUsuario'; 

import { Card, CardBody, CardHeader, Col, Container, Row } from 'reactstrap'; 

class FrmNavUsuario extends Component {

  render() {
    return (
      <div>
        <Container className="object-adjust">
          <Row className="justify-content-center">
            <Col md="12">
              <Card>
                <CardHeader><h3>USUÁRIOS</h3></CardHeader>            
                <CardBody>
                  <NavUsuario /> 
                </CardBody>
              </Card>
            </Col>
          </Row>
        </Container>
      </div>
    );
  }
}

export default FrmNavUsuario;
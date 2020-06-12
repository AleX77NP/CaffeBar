import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <NavMenu />
        <Container>
          {this.props.children}
            </Container>
            <div className="row">
                <div className="col">
                    <hr />
                    <small style={{ marginLeft: '46%' }}><strong>&copy; AMDevelop 2020</strong></small>
                    </div>
             </div>
      </div>
    );
  }
}

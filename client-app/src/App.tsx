import React, {Component} from "react";
import "./App.css";
import axios from 'axios'
import {Header, Icon} from "semantic-ui-react";

interface IValue{
  id : number;
  name: string;
}

class App extends Component {
  state = { values : [] }

  componentDidMount(){
    axios.get('http://localhost:5000/api/Values')
      .then( (response) => {
        this.setState( {values : response.data} );
      });
  }

  render() {
    
    return (
      <div className="App">
         <Header as='h2'>
            <Icon name='users' />
            <Header.Content>reactivities</Header.Content>
        </Header>
        <div className='List-container'>
         <ul>
            {
              this.state.values.map((value : IValue) => {
                return <li key={value.id}>{value.name}</li>
             })
            }
          </ul>
         </div>
      </div>
    );
  }
}

export default App;

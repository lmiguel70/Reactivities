import React from 'react';
import './App.css';
import { cars } from './demo'
import CarItem from './CarItem'

const App1 : React.FC = () => {
  return (
    <div className="App">
      <ul>
        {cars.map((car) =>
          { return <CarItem car={car} />}
        )}
      </ul>
    </div>
  );
}

export default App1;

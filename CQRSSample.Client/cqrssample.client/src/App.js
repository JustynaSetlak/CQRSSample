import React, { Component } from 'react';
import 'antd/dist/antd.css';
import ProductList from './components/ProductList/ProductList';

class App extends Component {
  render() {
    return (
      <div>
        <ProductList/>
      </div>
    );
  }
}

export default App;

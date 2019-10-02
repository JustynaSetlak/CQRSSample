import React, { Component } from 'react';
import AddNewProduct from '../AddNewProduct/AddNewProduct';
import { Button } from 'antd';

class ProductList extends Component {

  state = { shouldShowAddNewProductForm: false }

  setShouldShowAddNewProductForm = () => {
    this.setState({ shouldShowAddNewProductForm: !this.state.shouldShowAddNewProductForm })
  }

  handleShowingAddNewProductForm = () => {
    return this.state.shouldShowAddNewProductForm ? <AddNewProduct/> : null;
  }

  render() {
    return (
    <div>
      {this.handleShowingAddNewProductForm()}

      <Button disabled={this.state.shouldShowAddNewProductForm} onClick={this.setShouldShowAddNewProductForm}>Add new product</Button>
      
    </div>
    );
  }
}

export default ProductList;

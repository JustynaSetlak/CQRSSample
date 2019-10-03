import React, { Component } from 'react';
import { Button, Table } from 'antd';

import AddNewProduct from '../AddNewProduct/AddNewProduct';
import * as productApi from '../../api/ProductApi';
import * as constants from '../../constants/Constants';

class ProductList extends Component {
  
  state = { shouldShowAddNewProductForm: false }

  toggleShowingAddNewProductForm = () => {
    this.setState({ shouldShowAddNewProductForm: !this.state.shouldShowAddNewProductForm })
  }

  createProduct = async (product) => {
    const response = await productApi.createProductAsync(product);
    console.log(response);
  }

  handleShowingAddNewProductForm = () => {
    return this.state.shouldShowAddNewProductForm 
      ? <AddNewProduct cancelAddingNewProduct={this.toggleShowingAddNewProductForm} handleSubmit={this.createProduct}/> 
      : null;
  }

  render() {
    return (
    <div>
      {this.handleShowingAddNewProductForm()}
      <Button disabled={this.state.shouldShowAddNewProductForm} onClick={this.toggleShowingAddNewProductForm}>Add new product</Button>
      <Table columns={constants.productListColumns} dataSource={[]} />
    </div>
    );
  }
}

export default ProductList;

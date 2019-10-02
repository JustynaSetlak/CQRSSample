import React, { Component } from 'react';
import { Input, Icon, Button } from 'antd';
import TextArea from 'antd/lib/input/TextArea';

class AddNewProduct extends Component {
  render() {
    return (
    <div>
        <div>
            Fill to add new product
            <Input prefix={<Icon type="red-envelope" />} size="large" placeholder="Name"/>
            <TextArea rows={4} placeholder="Description"/>
            <Button type="primary">Add new product</Button>
            <Button type="link">Cancel</Button>
        </div>
    </div>
    );
  }
}

export default AddNewProduct;

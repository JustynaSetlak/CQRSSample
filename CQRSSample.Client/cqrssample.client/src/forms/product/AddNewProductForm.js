import React from 'react';
import { Input, Icon, Button } from 'antd';
import TextArea from 'antd/lib/input/TextArea';

const AddNewProductForm = props => {
    const {
      values,
      touched,
      errors,
      handleChange,
      handleBlur,
      handleSubmit,
      cancelAddingNewProduct
    } = props;
    return (
      <form onSubmit={handleSubmit}>
  
        <Input prefix={<Icon type="red-envelope" />} 
               size="large" 
               placeholder="Name" 
               type="text"
               onChange={handleChange}
               onBlur={handleBlur}
               value={values.name}
               name="name"/>
        {errors.name && touched.name && <div>{errors.name}</div>}
        
        <TextArea rows={4} 
                  placeholder="Description" 
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.description}
                  name="description"/>
        {errors.description && touched.description && <div>{errors.description}</div>}
  
        <Button type="primary" onClick={handleSubmit}>Add new product</Button>
        <Button onClick={cancelAddingNewProduct} type="link">Cancel</Button>    
      </form>
    );
  };

export default AddNewProductForm;
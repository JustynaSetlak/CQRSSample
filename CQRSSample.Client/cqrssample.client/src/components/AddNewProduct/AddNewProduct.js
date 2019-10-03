import { withFormik } from 'formik';
import AddNewProductForm from '../../forms/product/AddNewProductForm';

const AddNewProduct = withFormik({
  mapPropsToValues: () => ({ name: '', description: '' }),

  validate: values => {
    const errors = {};

    if (!values.name) {
      errors.name = 'Required';
    }

    if (!values.description) {
      errors.description = 'Required';
    }
    return errors;
  },

  handleSubmit: (values, { props }) => {
    props.handleSubmit(values);
  },
})(AddNewProductForm);

export default AddNewProduct;

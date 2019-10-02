import axios from 'axios';

const createProduct = async (product) => {
    const response = await axios.post("https://", product);
    console.log(response);
};
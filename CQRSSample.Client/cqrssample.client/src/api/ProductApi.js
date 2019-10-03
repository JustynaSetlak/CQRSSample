import axios from 'axios';

import * as constants from '../constants/Constants';

export const createProductAsync = async (product) => {
    const response = await axios.post(constants.baseUrl, product);
    console.log(response);
};
/* 
    Aqui será realizado a conexão com a web api. 
    E esta conexão será realizado através do 'axios' e como parâmetro receberá o valor adicionado ao arqivo .env
*/

import axios from 'axios' 
const api = axios.create({baseURL: process.env.REACT_APP_API_URL});

export default api; 
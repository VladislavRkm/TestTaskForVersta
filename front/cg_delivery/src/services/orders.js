import axios from "axios"

export const fetchOrders = async () => {
    try {
        var response = await axios.get("http://localhost:5298/orders");
        return response.data}
    catch(e){
        console.error(e);
    }
};

export const createOrder = async (order) => {
    try {
        var response = await axios.post("http://localhost:5298/orders", order);
        return response.status}
    catch(e){
        console.error(e);
    }
};
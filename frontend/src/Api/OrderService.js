import axios from "axios";

export default class OrderService {
    static ipServer = process.env.REACT_APP_IP_SERVER; 

    static async getAll() {
        console.log(this.ipServer)
        const response = await axios.get(`${this.ipServer}/api/Order/all`);
        return response;
    }

    static async createOrder(order) {
        const response = await axios.post(`${this.ipServer}/api/Order/createOrder`, order);
        return response;
    }
    static async getbyIdOrder(id) {
        const response = await axios.get(`${this.ipServer}/api/Order/${id}`);
        return response;
    }
}
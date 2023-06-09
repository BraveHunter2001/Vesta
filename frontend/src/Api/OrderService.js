import axios from "axios";

export default class OrderService {

    static async getAll() {
        const response = await axios.get("http://localhost:5140/api/Order/all");
        return response;
    }

    static async createOrder(order) {
        const response = await axios.post("http://localhost:5140/api/Order/createOrder", order);
        return response;
    }
    static async getbyIdOrder(id) {
        const response = await axios.get(`http://localhost:5140/api/Order/${id}`);
        return response;
    }
}
import axios from "axios";

const httpClient = axios.create({
    baseURL: process.env.API_ENDPOINT,
    timeout: 1000,
    headers: {
        "Content-Type": "application/json"
        // Anything I want to add to the headers
    }
});

export default httpClient;
import axios from 'axios';

const API_URL = 'https://localhost:7117/api/clients';

const getClients = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data;
  } catch (error) {
    console.error("Error fetching clients:", error.response || error);
    throw error; 
  }
};

const getClientById = async (id) => {
  try {
    const response = await axios.get(`${API_URL}/${id}`);
    console.log("Client data fetched successfully:", response.data); 
    return response.data;
  } catch (error) {
    console.error("Error fetching client data:", error.response || error);
    throw error; 
  }
};


const createClient = async (client) => {
  try {
    const response = await axios.post(API_URL, client);
    return response.data;
  } catch (error) {
    console.error("Error creating client:", error.response || error);
    alert("Error creating client. Please try again later.");
    throw error;  
  }
};

const updateClient = async (id, client) => {
  try {
    const response = await axios.put(`${API_URL}/${id}`, client);
    console.log("Client updated successfully:", response.data); 
    return response.data;
  } catch (error) {
    console.error("Error updating client:", error.response || error); 
    if (error.response) {
      console.log("Error details:", error.response.data);
    }
    alert("Error updating client. Please try again later.");
    throw error;  
  }
};

const deleteClient = async (id) => {
  try {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
  } catch (error) {
    console.error("Error deleting client:", error.response || error);
    alert("Error deleting client. Please try again later.");
    throw error;  
  }
};

export { getClients, getClientById, createClient, updateClient, deleteClient };

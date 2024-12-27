import axios from 'axios';

// URL për API-në
const API_URL = 'https://localhost:7117/api/clients';

// Funksioni për të marrë të gjithë klientët
const getClients = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data;
  } catch (error) {
    console.error("Error fetching clients:", error.response || error);
    throw error; // Hedhim gabimin për ta kapur në frontend
  }
};

// Funksioni për të marrë një klient sipas ID-së
const getClientById = async (id) => {
  try {
    const response = await axios.get(`${API_URL}/${id}`);
    console.log("Client data fetched successfully:", response.data); // Kontrolloni të dhënat
    return response.data;
  } catch (error) {
    console.error("Error fetching client data:", error.response || error);
    throw error; // Hedhim gabimin për t'u kapur në frontend
  }
};


// Funksioni për të krijuar një klient të ri
const createClient = async (client) => {
  try {
    const response = await axios.post(API_URL, client);
    return response.data;
  } catch (error) {
    console.error("Error creating client:", error.response || error);
    alert("Error creating client. Please try again later.");
    throw error;  // Hedhim gabimin që mund të kapet në frontend
  }
};

// Funksioni për të përditësuar një klient
const updateClient = async (id, client) => {
  try {
    const response = await axios.put(`${API_URL}/${id}`, client);
    console.log("Client updated successfully:", response.data); // Log për suksesin
    return response.data;
  } catch (error) {
    console.error("Error updating client:", error.response || error); // Log gabimin për debug
    if (error.response) {
      // Nëse ka një përgjigje nga serveri
      console.log("Error details:", error.response.data);
    }
    alert("Error updating client. Please try again later.");
    throw error;  // Hedhim përsëri gabimin për ta kapur në frontend
  }
};

// Funksioni për të fshirë një klient
const deleteClient = async (id) => {
  try {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
  } catch (error) {
    console.error("Error deleting client:", error.response || error);
    alert("Error deleting client. Please try again later.");
    throw error;  // Hedhim gabimin për ta kapur në frontend
  }
};

export { getClients, getClientById, createClient, updateClient, deleteClient };

import React, { createContext, useState, useContext, useEffect } from 'react';
import axios from 'axios';

const ClientContext = createContext();

export const ClientProvider = ({ children }) => {
  const [clients, setClients] = useState([]);  
  const [loading, setLoading] = useState(false); 
  const [error, setError] = useState(null); 

  const fetchClients = async () => {
    setLoading(true);
    try {
      const response = await axios.get('/api/clients');  
      setClients(response.data);
      setLoading(false);
    } catch (err) {
      setError('Gabim gjatë ngarkimit të të dhënave');
      setLoading(false);
    }
  };

  const addClient = async (newClient) => {
    try {
      const response = await axios.post('/api/clients', newClient); 
      setClients([...clients, response.data]);
    } catch (err) {
      setError('Gabim gjatë shtimit të klientit');
    }
  };

  const updateClient = async (id, updatedClient) => {
    try {
      const response = await axios.put(`/api/clients/${id}`, updatedClient);
      setClients(clients.map(client => client.id === id ? response.data : client));
    } catch (err) {
      setError('Gabim gjatë përditësimit të klientit');
    }
  };

  const deleteClient = async (id) => {
    try {
      await axios.delete(`/api/clients/${id}`);
      setClients(clients.filter(client => client.id !== id));
    } catch (err) {
      setError('Gabim gjatë fshirjes së klientit');
    }
  };

  useEffect(() => {
    fetchClients();  
  }, []);

  return (
    <ClientContext.Provider value={{ clients, addClient, updateClient, deleteClient, loading, error }}>
      {children}
    </ClientContext.Provider>
  );
};

export const useClientContext = () => {
  return useContext(ClientContext);
};

import axios from 'axios';
import { toast } from 'react-toastify';  

const API_URL = 'https://localhost:7117/api/reservations';

export const createReservation = async (reservationData) => {
  try {
    const response = await axios.post(API_URL, reservationData, { timeout: 5000 });
    toast.success("Reservation created successfully!");  
    return response.data;
  } catch (error) {
    console.error("Error creating reservation:", error);
    toast.error("Error creating reservation!");  
    throw error;
  }
};

export const getReservations = async () => {
  try {
    const response = await axios.get(API_URL, { timeout: 5000 });
    return response.data;
  } catch (error) {
    console.error("Error fetching reservations:", error);
    toast.error("Error fetching reservations!");  
    throw error;
  }
};

export const confirmReservation = async (id) => {
  try {
    const response = await axios.put(`${API_URL}/confirm/${id}`, {}, { timeout: 5000 });
    toast.success("Reservation confirmed!");  
    return response.data;
  } catch (error) {
    console.error("Error confirming reservation:", error);
    toast.error("Error confirming reservation!");  
    throw error;
  }
};

export const cancelReservation = async (id) => {
  try {
    const response = await axios.put(`${API_URL}/cancel/${id}`, {}, { timeout: 5000 });
    toast.success("Reservation cancelled!");  
    return response.data;
  } catch (error) {
    console.error("Error cancelling reservation:", error);
    toast.error("Error cancelling reservation!");  
    throw error;
  }
};

export const deleteReservation = async (id) => {
  try {
    const response = await axios.delete(`${API_URL}/${id}`, { timeout: 5000 });
    toast.success("Reservation deleted!");  
    return response.data;
  } catch (error) {
    console.error("Error deleting reservation:", error);
    toast.error("Error deleting reservation!"); 
    throw error;
  }
};

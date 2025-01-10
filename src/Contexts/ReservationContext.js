import React, { createContext, useContext, useState, useCallback } from 'react';
import { getReservations, confirmReservation, cancelReservation, deleteReservation } from '../Services/ReservationService';

const ReservationContext = createContext();

export const useReservationContext = () => {
  return useContext(ReservationContext);
};

export const ReservationProvider = ({ children }) => {
  const [reservations, setReservations] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  const fetchReservations = useCallback(async () => {
    setLoading(true);
    try {
      const data = await getReservations();
      setReservations(data);
    } catch (error) {
      setError('Failed to fetch reservations.');
    } finally {
      setLoading(false);
    }
  }, []); 

  const handleConfirmReservation = async (id) => {
    setLoading(true);
    try {
      await confirmReservation(id);
      setReservations((prevReservations) =>
        prevReservations.map((reservation) =>
          reservation.id === id ? { ...reservation, status: "Confirmed" } : reservation
        )
      );
    } catch (error) {
      setError('Failed to confirm reservation.');
    } finally {
      setLoading(false);
    }
  };

  const handleCancelReservation = async (id) => {
    setLoading(true);
    try {
      await cancelReservation(id);
      setReservations((prevReservations) =>
        prevReservations.map((reservation) =>
          reservation.id === id ? { ...reservation, status: "Cancelled" } : reservation
        )
      );
    } catch (error) {
      setError('Failed to cancel reservation.');
    } finally {
      setLoading(false);
    }
  };

  const handleDeleteReservation = async (id) => {
    try {
      await deleteReservation(id);
      setReservations((prevReservations) =>
        prevReservations.filter((reservation) => reservation.id !== id)
      );
    } catch (error) {
      setError('Failed to delete reservation.');
    }
  };

  return (
    <ReservationContext.Provider
      value={{
        reservations,
        loading,
        error,
        fetchReservations,
        handleConfirmReservation,
        handleCancelReservation,
        handleDeleteReservation
      }}
    >
      {children}
    </ReservationContext.Provider>
  );
};

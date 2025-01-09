import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const ReservationDetails = () => {
  const { secretId } = useParams();
  const [reservationDetails, setReservationDetails] = useState(null);

  useEffect(() => {
    const fetchReservationDetails = async () => {
      try {
        const response = await axios.get(`https://localhost:7117/api/reservations/details/${secretId}`);
        setReservationDetails(response.data);
        toast.success('Detajet e rezervimit janë ngarkuar me sukses!');
      } catch (error) {
        console.error('Gabim gjatë marrjes së të dhënave për rezervimin:', error);
        toast.error('Gabim gjatë ngarkimit të të dhënave të rezervimit');
      }
    };

    if (secretId) {
      fetchReservationDetails();
    }
  }, [secretId]);

  if (!reservationDetails) {
    return <div>Po ngarkohen të dhënat...</div>;
  }

  return (
    <div className="min-h-screen flex items-center justify-center bg-cover bg-center" style={{ backgroundImage: "url('/Images/background.jpg')" }}>
      <div className="w-full max-w-2xl p-8 bg-white/90 rounded-lg shadow-xl">
        <h2 className="text-3xl font-bold mb-8 text-center text-blue-600">Detajet e Rezervimit</h2>
        <div className="space-y-4">
          <p><strong>Emri i Klientit:</strong> {reservationDetails.clientName}</p>
          <p><strong>Numri i Telefonit:</strong> {reservationDetails.clientPhoneNumber}</p>
          <p><strong>Numri i Mysafirëve:</strong> {reservationDetails.numberOfGuests}</p>
          <p><strong>Data e Rezervimit:</strong> {new Date(reservationDetails.reservationDate).toLocaleString()}</p>
          <p><strong>Statusi:</strong> {reservationDetails.status}</p>
        </div>
        <ToastContainer />
      </div>
    </div>
  );
};

export default ReservationDetails;

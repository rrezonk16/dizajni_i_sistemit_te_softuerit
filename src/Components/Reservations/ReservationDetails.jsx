import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { getReservationDetails } from '../../Services/ReservationService';




const ReservationDetails = () => {
  const { secretId } = useParams();
  const [reservationDetails, setReservationDetails] = useState(null);
  const [loading, setLoading] = useState(true); // To handle loading state
  const [error, setError] = useState(null); // To handle errors

  useEffect(() => {
    const fetchReservationDetails = async () => {
      try {
        setLoading(true); // Start loading when fetching
        setError(null); // Reset any previous error

        const details = await getReservationDetails(secretId);

        if (!details) {
          throw new Error('Detajet e rezervimit nuk u gjetën.');
        }

        setReservationDetails(details);
        toast.success('Detajet e rezervimit janë ngarkuar me sukses!');
      } catch (error) {
        console.error('Error fetching reservation details:', error);
        setError(error.message); // Set error message if failed
        toast.error(error.message || 'Gabim gjatë ngarkimit të detajeve të rezervimit');
      } finally {
        setLoading(false); // Stop loading after fetching
      }
    };

    if (secretId) {
      fetchReservationDetails();
    }
  }, [secretId]);

  // If still loading
  if (loading) {
    return <div>Po ngarkohen të dhënat...</div>;
  }

  // If error occurs
  if (error) {
    return <div className="text-red-500">Ndodhi një gabim: {error}</div>;
  }

  // If no reservation found
  if (!reservationDetails) {
    return <div>Rezervimi nuk u gjet.</div>;
  }

  return (
    <div
      className="min-h-screen flex items-center justify-center bg-cover bg-center"
      style={{ backgroundImage: "url('/Images/background.jpg')" }}
    >
      <div className="w-full max-w-2xl p-8 bg-white/90 rounded-lg shadow-xl">
        <h2 className="text-3xl font-bold mb-8 text-center text-blue-600">Detajet e Rezervimit</h2>
        <div className="space-y-4">
          <p><strong>Emri i Klientit:</strong> {reservationDetails.clientName}</p>
          <p><strong>Numri i Telefonit:</strong> {reservationDetails.clientPhoneNumber}</p>
          <p><strong>Numri i Mysafirëve:</strong> {reservationDetails.numberOfGuests}</p>
          <p><strong>Data e Rezervimit:</strong> {new Date(reservationDetails.reservationDate).toLocaleString()}</p>
          <p><strong>Statusi:</strong> {reservationDetails.status}</p>
        </div>
      </div>
    </div>
  );
};

export default ReservationDetails;

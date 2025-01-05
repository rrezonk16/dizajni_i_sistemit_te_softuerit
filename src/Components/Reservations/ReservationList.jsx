import React, { useEffect } from "react";
import { useReservationContext } from "../../Contexts/ReservationContext";
import { Link } from "react-router-dom";
import moment from "moment-timezone";
import { toast } from "react-toastify"; 
import {
  deleteReservation,
  confirmReservation,
  cancelReservation,
} from "../../Services/ReservationService";

const getStatusColor = (status) => {
  switch (status) {
    case "Pending":
      return "bg-yellow-500";
    case "Confirmed":
      return "bg-green-500";
    case "Cancelled":
      return "bg-red-500";
    default:
      return "bg-gray-500";
  }
};

const TableRow = ({ reservation, onConfirm, onCancel, onDelete }) => {
  const formattedDate = moment(reservation.reservationDate)
    .tz("Europe/Belgrade")
    .format("LLL");

  return (
    <tr className="hover:bg-gray-50 transition duration-200">
      <td className="py-3 px-4 border-b text-gray-700">{reservation.id}</td>
      <td className="py-3 px-4 border-b text-gray-700">{reservation.clientName}</td>
      <td className="py-3 px-4 border-b text-gray-700">{reservation.clientPhoneNumber}</td>
      <td className="py-3 px-4 border-b text-gray-700">{reservation.numberOfGuests}</td>
      <td className="py-3 px-4 border-b text-gray-700">{formattedDate}</td>
      <td className={`py-3 px-4 border-b text-white font-semibold ${getStatusColor(reservation.status)}`}>
        {reservation.status}
      </td>

      <td className="py-3 px-4 border-b flex gap-2">
        {reservation.status === "Pending" && (
          <>
            <button
              onClick={() => onConfirm(reservation.id)}
              className="bg-green-500 hover:bg-green-600 text-white px-4 py-2 rounded-lg shadow"
            >
              Confirm
            </button>
            <button
              onClick={() => onCancel(reservation.id)}
              className="bg-yellow-500 hover:bg-yellow-600 text-white px-4 py-2 rounded-lg shadow"
            >
              Cancel
            </button>
          </>
        )}
        <button
          onClick={() => onDelete(reservation.id)}
          className="bg-red-500 hover:bg-red-600 text-white px-4 py-2 rounded-lg shadow"
        >
          Delete
        </button>
      </td>
    </tr>
  );
};

const ReservationList = () => {
  const { reservations, setReservations, loading, error, fetchReservations } = useReservationContext();

  useEffect(() => {
    const fetchAndSetReservations = async () => {
      try {
        const fetchedReservations = await fetchReservations(); 
        setReservations(fetchedReservations); 
      } catch (error) {
        console.error("Error fetching reservations:", error);
      }
    };

    fetchAndSetReservations(); 
  }, [fetchReservations, setReservations]);

  const handleConfirmReservation = async (id) => {
    try {
      await confirmReservation(id);
      fetchReservations();
      toast.success("Rezervimi është konfirmuar me sukses!"); 
    } catch (error) {
      console.error("Error confirming reservation:", error);
      toast.error("Gabim gjatë konfirmimit të rezervimit."); 
    }
  };

  const handleCancelReservation = async (id) => {
    try {
      await cancelReservation(id);
      fetchReservations();
      toast.warning("Rezervimi është anuluar."); 
    } catch (error) {
      console.error("Error cancelling reservation:", error);
      toast.error("Gabim gjatë anulimit të rezervimit."); 
    }
  };

  const handleDeleteReservation = async (id) => {
    if (window.confirm("Jeni i sigurt që dëshironi ta fshini këtë rezervim?")) {
      try {
        await deleteReservation(id);
        fetchReservations();
        toast.error("Rezervimi është fshirë."); 
      } catch (error) {
        console.error("Error deleting reservation:", error);
        toast.error("Gabim gjatë fshirjes së rezervimit."); 
      }
    }
  };

  if (loading)
    return (
      <div className="min-h-screen flex justify-center items-center">
        <div className="animate-pulse space-y-4 w-full max-w-md">
          <div className="h-10 bg-gray-300 rounded"></div>
          <div className="h-10 bg-gray-300 rounded"></div>
          <div className="h-10 bg-gray-300 rounded"></div>
        </div>
      </div>
    );

  if (error)
    return <div className="text-center text-red-500 text-lg mt-6">{error}</div>;

  return (
    <div
      className="min-h-screen bg-cover bg-center relative"
      style={{
        backgroundImage: "url('/images/background.jpg')",
      }}
    >
      <div className="absolute inset-0 bg-black opacity-50"></div>

      <div className="relative container mx-auto py-8 px-4">
        <h2 className="text-4xl font-extrabold text-center mb-6 text-white">
          Reservation List
        </h2>

        <div className="overflow-x-auto shadow-xl rounded-lg bg-white/90">
          <table className="min-w-full border border-gray-300">
            <thead>
              <tr className="bg-gray-200 text-gray-800">
                <th className="py-3 px-4 text-left font-semibold">ID</th>
                <th className="py-3 px-4 text-left font-semibold">Client Name</th>
                <th className="py-3 px-4 text-left font-semibold">Phone Number</th>
                <th className="py-3 px-4 text-left font-semibold">Guests</th>
                <th className="py-3 px-4 text-left font-semibold">Date</th>
                <th className="py-3 px-4 text-left font-semibold">Status</th>
                <th className="py-3 px-4 text-left font-semibold">Actions</th>
              </tr>
            </thead>
            <tbody>
              {reservations.map((reservation) => (
                <TableRow
                  key={reservation.id}
                  reservation={reservation}
                  onConfirm={handleConfirmReservation}
                  onCancel={handleCancelReservation}
                  onDelete={handleDeleteReservation}
                />
              ))}
            </tbody>
          </table>
        </div>

        <div className="text-center mt-6">
          <Link
            to="/create-reservation"
            className="bg-blue-500 hover:bg-blue-600 text-white px-6 py-2 rounded-full shadow transition"
          >
            Create New Reservation
          </Link>
        </div>
      </div>
    </div>
  );
};

export default ReservationList;

import React, { useState } from 'react';
import { useForm } from 'react-hook-form';
import * as Yup from 'yup';
import { yupResolver } from '@hookform/resolvers/yup';
import { ToastContainer, toast } from 'react-toastify';
import { useNavigate } from 'react-router-dom';
import { QRCodeSVG } from 'qrcode.react';
import { createReservation } from '../../Services/ReservationService';

const CreateReservation = () => {
  const [qrCodeUrl, setQrCodeUrl] = useState('');
  const navigate = useNavigate();

  // Validimi me Yup
  const schema = Yup.object().shape({
    clientName: Yup.string().required('Emri i klientit është i detyrueshëm'),
    clientPhoneNumber: Yup.string()
      .required('Numri i telefonit është i detyrueshëm')
      .matches(/^[0-9]{9}$/, 'Numri duhet të jetë 9 shifra'),
    numberOfGuests: Yup.number()
      .required('Numri i mysafirëve është i detyrueshëm')
      .positive('Numri i mysafirëve duhet të jetë pozitiv')
      .integer('Numri i mysafirëve duhet të jetë një numër i plotë'),
    reservationDate: Yup.date().required('Data e rezervimit është e detyrueshme'),
  });

  const { register, handleSubmit, formState: { errors } } = useForm({
    resolver: yupResolver(schema),
  });

  // Funksioni për krijimin e rezervimit
  const onSubmit = async (data) => {
    try {
      const response = await createReservation(data); // Përdorimi i funksionit nga ReservationService
      console.log("Test",response)
      if (response && response.secretId) {
        const qrCodeValue = `http://95.86.58.117/reservation/${response.secretId}`;
        setQrCodeUrl(qrCodeValue);

        toast.success('Rezervimi është krijuar me sukses');
        navigate(`/reservation-success/${response.secretId}`);
      } else {
        toast.error('Nuk u gjend SecretId në përgjigjen e serverit');
      }
    } catch (error) {
      console.error('Gabim i plotë:', error.response || error);
      toast.error(
        error.response?.data?.message || 'Gabim gjatë dërgimit të të dhënave'
      );
    }
  };

  return (
    <div
      className="min-h-screen flex items-center justify-center bg-cover bg-center"
      style={{
        backgroundImage: "url('/Images/background.jpg')",
      }}
    >
      <div className="w-full max-w-2xl p-8 bg-white/90 rounded-lg shadow-xl">
        <h2 className="text-3xl font-bold mb-8 text-center text-blue-600">
          Krijo Rezervimin
        </h2>

        {/* Forma për krijimin e rezervimit */}
        <form onSubmit={handleSubmit(onSubmit)} className="space-y-6">
          {/* Emri i Klientit */}
          <div className="mb-6">
            <label htmlFor="clientName" className="block text-gray-700 font-medium">
              Emri i Klientit
            </label>
            <input
              type="text"
              id="clientName"
              {...register('clientName')}
              className="w-full p-3 border-2 border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
              placeholder="Shkruani emrin e klientit"
            />
            {errors.clientName && (
              <p className="text-red-500">{errors.clientName.message}</p>
            )}
          </div>

          {/* Numri i Telefonit */}
          <div className="mb-6">
            <label htmlFor="clientPhoneNumber" className="block text-gray-700 font-medium">
              Numri i Telefonit
            </label>
            <input
              type="text"
              id="clientPhoneNumber"
              {...register('clientPhoneNumber')}
              className="w-full p-3 border-2 border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
              placeholder="Shkruani numrin e telefonit"
            />
            {errors.clientPhoneNumber && (
              <p className="text-red-500">{errors.clientPhoneNumber.message}</p>
            )}
          </div>

          {/* Numri i Mysafirëve */}
          <div className="mb-6">
            <label htmlFor="numberOfGuests" className="block text-gray-700 font-medium">
              Numri i Mysafirëve
            </label>
            <input
              type="number"
              id="numberOfGuests"
              {...register('numberOfGuests')}
              className="w-full p-3 border-2 border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
              placeholder="Shkruani numrin e mysafirëve"
            />
            {errors.numberOfGuests && (
              <p className="text-red-500">{errors.numberOfGuests.message}</p>
            )}
          </div>

          {/* Data e Rezervimit */}
          <div className="mb-6">
            <label htmlFor="reservationDate" className="block text-gray-700 font-medium">
              Data e Rezervimit
            </label>
            <input
              type="datetime-local"
              id="reservationDate"
              {...register('reservationDate')}
              className="w-full p-3 border-2 border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
            />
            {errors.reservationDate && (
              <p className="text-red-500">{errors.reservationDate.message}</p>
            )}
          </div>

          {/* Butoni Krijo */}
          <button
            type="submit"
            className="w-full bg-blue-600 text-white p-4 rounded-lg shadow-lg hover:bg-blue-700 transition duration-300"
          >
            Krijo Rezervimin
          </button>
        </form>

        {/* QR Code */}
        {qrCodeUrl && (
          <div className="mt-8 text-center">
            <h3 className="text-lg font-bold text-gray-700 mb-4">
              Skanoni QR Code për të parë rezervimin:
            </h3>
            <QRCodeSVG value={qrCodeUrl} size={256} />
          </div>
        )}
      </div>

      <ToastContainer />
    </div>
  );
};

export default CreateReservation;

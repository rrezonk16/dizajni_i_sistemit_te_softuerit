import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useForm } from 'react-hook-form';
import * as Yup from 'yup';
import { yupResolver } from '@hookform/resolvers/yup';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'; 

const ReservationForm = ({ reservationId, onSuccess }) => {
  const [isEdit, setIsEdit] = useState(false);
  const [errorMessage, setErrorMessage] = useState('');
  const [successMessage, setSuccessMessage] = useState('');

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

  const { register, handleSubmit, formState: { errors }, setValue } = useForm({
    resolver: yupResolver(schema),
  });

  useEffect(() => {
    if (reservationId) {
      setIsEdit(true);
      axios.get(`https://localhost:7117/api/reservations/${reservationId}`)
        .then(response => {
          const { clientName, clientPhoneNumber, numberOfGuests, reservationDate } = response.data;
          setValue('clientName', clientName);
          setValue('clientPhoneNumber', clientPhoneNumber);
          setValue('numberOfGuests', numberOfGuests);
          setValue('reservationDate', reservationDate);
        })
        .catch(() => {
          setErrorMessage('Gabim gjatë ngarkimit të rezervimit');
        });
    }
  }, [reservationId, setValue]);

  const onSubmit = async (data) => {
    setErrorMessage('');
    setSuccessMessage('');
    try {
      if (isEdit) {
        await axios.put(`https://localhost:7117/api/reservations/${reservationId}`, data);
        toast.success('Rezervimi është përditësuar me sukses'); 
      } else {
        await axios.post('https://localhost:7117/api/reservations', data);
        toast.success('Rezervimi është krijuar me sukses'); 
      }
      onSuccess && onSuccess();
    } catch (error) {
      console.error('Gabim i plotë:', error.response || error);
      if (error.response && error.response.data) {
        toast.error(error.response.data.message || 'Gabim gjatë dërgimit të të dhënave'); 
      } else {
        toast.error('Gabim i panjohur ndodhi'); 
      }
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
          {isEdit ? 'Përditëso Rezervimin' : 'Krijo Rezervimin'}
        </h2>

        {errorMessage && <div className="text-red-500 mb-4">{errorMessage}</div>}
        {successMessage && <div className="text-green-500 mb-4">{successMessage}</div>}

        <form onSubmit={handleSubmit(onSubmit)} className="space-y-6">
          <div className="mb-6">
            <label htmlFor="clientName" className="block text-gray-700 font-medium">Emri i Klientit</label>
            <input
              type="text"
              id="clientName"
              name="clientName"
              {...register('clientName')}
              className="w-full p-3 border-2 border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
              placeholder="Shkruani emrin e klientit"
            />
            {errors.clientName && <p className="text-red-500">{errors.clientName.message}</p>}
          </div>

          <div className="mb-6">
            <label htmlFor="clientPhoneNumber" className="block text-gray-700 font-medium">Numri i Telefonit</label>
            <input
              type="text"
              id="clientPhoneNumber"
              name="clientPhoneNumber"
              {...register('clientPhoneNumber')}
              className="w-full p-3 border-2 border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
              placeholder="Shkruani numrin e telefonit"
            />
            {errors.clientPhoneNumber && <p className="text-red-500">{errors.clientPhoneNumber.message}</p>}
          </div>

          <div className="mb-6">
            <label htmlFor="numberOfGuests" className="block text-gray-700 font-medium">Numri i Mysafirëve</label>
            <input
              type="number"
              id="numberOfGuests"
              name="numberOfGuests"
              {...register('numberOfGuests')}
              className="w-full p-3 border-2 border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
              placeholder="Shkruani numrin e mysafirëve"
            />
            {errors.numberOfGuests && <p className="text-red-500">{errors.numberOfGuests.message}</p>}
          </div>

          <div className="mb-6">
            <label htmlFor="reservationDate" className="block text-gray-700 font-medium">Data e Rezervimit</label>
            <input
              type="datetime-local"
              id="reservationDate"
              name="reservationDate"
              {...register('reservationDate')}
              className="w-full p-3 border-2 border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
            />
            {errors.reservationDate && <p className="text-red-500">{errors.reservationDate.message}</p>}
          </div>

          <button type="submit" className="w-full bg-blue-600 text-white p-4 rounded-lg shadow-lg hover:bg-blue-700 transition duration-300">
            {isEdit ? 'Përditëso' : 'Krijo'} Rezervimin
          </button>
        </form>
      </div>

      <ToastContainer /> 
    </div>
  );
};

export default ReservationForm;

import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useForm } from 'react-hook-form';
import * as Yup from 'yup';
import { yupResolver } from '@hookform/resolvers/yup';

const ClientForm = ({ clientId, onSuccess }) => {
  const [isEdit, setIsEdit] = useState(false);
  const [errorMessage, setErrorMessage] = useState('');
  const [successMessage, setSuccessMessage] = useState('');

  const schema = Yup.object().shape({
    name: Yup.string()
      .required('Emri është i detyrueshëm')
      .min(3, 'Emri duhet të ketë të paktën 3 shkronja'),
    email: Yup.string()
      .email('Emaili nuk është valid')
      .required('Emaili është i detyrueshëm'),
    phoneNumber: Yup.string()
      .required('Numri i telefonit është i detyrueshëm')
      .matches(/^[0-9]{9}$/, 'Numri duhet të jetë 9 shifra'),
  });

  const { register, handleSubmit, formState: { errors }, setValue } = useForm({
    resolver: yupResolver(schema),
  });

  useEffect(() => {
    if (clientId) {
      setIsEdit(true);
      axios.get(`https://localhost:7117/api/clients/${clientId}`)
        .then(response => {
          const { name, email, phoneNumber } = response.data;
          setValue('name', name);
          setValue('email', email);
          setValue('phoneNumber', phoneNumber);
        })
        .catch(() => {
          setErrorMessage('Gabim gjatë ngarkimit të klientit');
        });
    }
  }, [clientId, setValue]);

  const onSubmit = async (data) => {
    setErrorMessage('');
    setSuccessMessage('');
    try {
      if (isEdit) {
        await axios.put(`http://localhost:7117/api/clients/${clientId}`, data);
        setSuccessMessage('Klienti është përditësuar me sukses');
      } else {
        await axios.post('https://localhost:7117/api/clients', data);
        setSuccessMessage('Klienti është krijuar me sukses');
      }
      onSuccess && onSuccess();
    } catch (error) {
      console.error('Gabim i plotë:', error.response || error);
      if (error.response && error.response.data) {
        setErrorMessage(error.response.data.message || 'Gabim gjatë dërgimit të të dhënave');
      } else {
        setErrorMessage('Gabim i panjohur ndodhi');
      }
    }
  };

  const handleDelete = async () => {
    try {
      await axios.delete(`http://localhost:7117/api/clients/${clientId}`);
      setSuccessMessage('Klienti është fshirë me sukses');
      onSuccess && onSuccess();
    } catch (error) {
      console.error('Gabim i plotë:', error.response || error);
      setErrorMessage('Gabim gjatë fshirjes së klientit');
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
          {isEdit ? 'Përditëso Klientin' : 'Krijo Klientin'}
        </h2>

        {errorMessage && <div className="text-red-500 mb-4">{errorMessage}</div>}
        {successMessage && <div className="text-green-500 mb-4">{successMessage}</div>}

        <form onSubmit={handleSubmit(onSubmit)} className="space-y-6">
          <div className="mb-6">
            <label htmlFor="name" className="block text-gray-700 font-medium">Emri</label>
            <input
              type="text"
              id="name"
              name="name"
              {...register('name')}
              className="w-full p-3 border-2 border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
              placeholder="Shkruani emrin"
            />
            {errors.name && <p className="text-red-500">{errors.name.message}</p>}
          </div>
          
          <div className="mb-6">
            <label htmlFor="email" className="block text-gray-700 font-medium">Email</label>
            <input
              type="email"
              id="email"
              name="email"
              {...register('email')}
              className="w-full p-3 border-2 border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
              placeholder="Shkruani emailin"
            />
            {errors.email && <p className="text-red-500">{errors.email.message}</p>}
          </div>

          <div className="mb-6">
            <label htmlFor="phoneNumber" className="block text-gray-700 font-medium">Numri i Telefonit</label>
            <input
              type="text"
              id="phoneNumber"
              name="phoneNumber"
              {...register('phoneNumber')}
              className="w-full p-3 border-2 border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
              placeholder="Shkruani numrin e telefonit"
            />
            {errors.phoneNumber && <p className="text-red-500">{errors.phoneNumber.message}</p>}
          </div>

          <button type="submit" className="w-full bg-blue-600 text-white p-4 rounded-lg shadow-lg hover:bg-blue-700 transition duration-300">
            {isEdit ? 'Përditëso' : 'Krijo'} Klientin
          </button>
        </form>

        {isEdit && (
          <button
            className="mt-6 w-full bg-red-600 text-white p-4 rounded-lg shadow-lg hover:bg-red-700 transition duration-300"
            onClick={handleDelete}
          >
            Fshi Klientin
          </button>
        )}
      </div>
    </div>
  );
};

export default ClientForm;

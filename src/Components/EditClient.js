import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { getClientById, updateClient } from "../Services/ClientService";
import { useClientContext } from "../Contexts/ClientContext";

const EditClient = () => {
  const { clientId } = useParams();
  const navigate = useNavigate();
  const { updateClientContext } = useClientContext();

  const [client, setClient] = useState({
    name: "",
    email: "",
    phoneNumber: "",
  });
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchClientData = async () => {
      if (!clientId) {
        setError("Invalid client ID!");
        setLoading(false);
        return;
      }

      try {
        const clientData = await getClientById(clientId);
        setClient(clientData);
      } catch (err) {
        console.error("Error fetching client data:", err);
        setError("Failed to fetch client data. Please try again.");
      } finally {
        setLoading(false);
      }
    };

    fetchClientData();
  }, [clientId]);

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      await updateClient(clientId, client);
      updateClientContext(client);
      alert("Client updated successfully!");
      navigate("/clients");
    } catch (err) {
      console.error("Error updating client:", err);
      alert("Failed to update the client. Please try again.");
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setClient((prevClient) => ({
      ...prevClient,
      [name]: value,
    }));
  };

  if (loading) {
    return <div className="text-center mt-4">Loading client data...</div>;
  }

  if (error) {
    return (
      <div className="text-center mt-4 text-red-500">
        {error}
        <button
          onClick={() => navigate("/clients")}
          className="block mt-4 px-4 py-2 bg-blue-500 text-white rounded"
        >
          Go Back
        </button>
      </div>
    );
  }

  return (
    <div
      className="min-h-screen bg-cover bg-center relative"
      style={{
        backgroundImage: "url('/images/background.jpg')",
      }}
    >
      <div className="absolute inset-0 bg-black opacity-50"></div>

      <div className="relative container mx-auto p-4">
        <h2 className="text-4xl text-center mb-4 text-white">Edit Client</h2>
        <form
          onSubmit={handleSubmit}
          className="max-w-lg mx-auto bg-white/90 p-6 rounded-lg shadow"
        >
          <div className="mb-4">
            <label className="block text-gray-700">Name</label>
            <input
              type="text"
              name="name"
              value={client.name}
              onChange={handleChange}
              className="w-full px-4 py-2 border rounded-lg"
              required
            />
          </div>
          <div className="mb-4">
            <label className="block text-gray-700">Email</label>
            <input
              type="email"
              name="email"
              value={client.email}
              onChange={handleChange}
              className="w-full px-4 py-2 border rounded-lg"
              required
            />
          </div>
          <div className="mb-4">
            <label className="block text-gray-700">Phone Number</label>
            <input
              type="text"
              name="phoneNumber"
              value={client.phoneNumber}
              onChange={handleChange}
              className="w-full px-4 py-2 border rounded-lg"
              required
            />
          </div>
          <button
            type="submit"
            className="w-full bg-blue-500 text-white py-2 rounded-lg"
          >
            Update Client
          </button>
          <button
            type="button"
            onClick={() => navigate("/clients")}
            className="w-full bg-gray-500 text-white py-2 rounded-lg mt-2"
          >
            Cancel
          </button>
        </form>
      </div>
    </div>
  );
};

export default EditClient;

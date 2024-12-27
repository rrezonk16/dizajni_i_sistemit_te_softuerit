import React from "react";
import { useClientContext } from "../Contexts/ClientContext";
import { Link } from "react-router-dom"; // Importo Link për navigim
import moment from "moment-timezone";

const TableRow = ({ client, deleteClient }) => {
  const localCreatedAt = moment(client.createdAt)
    .tz("Europe/Belgrade")
    .format("YYYY-MM-DD HH:mm:ss");

  return (
    <tr className="hover:bg-gray-50 transition duration-200">
      <td className="py-3 px-4 border-b text-gray-700">{client.id}</td>
      <td className="py-3 px-4 border-b text-gray-700">{client.name}</td>
      <td className="py-3 px-4 border-b text-gray-700">{client.email}</td>
      <td className="py-3 px-4 border-b text-gray-700">{client.phoneNumber}</td>
      <td className="py-3 px-4 border-b text-gray-700">{localCreatedAt}</td>
      <td className="py-3 px-4 border-b">
        {/* Përdorni Link për navigim në EditClient me clientId */}
        <Link
          to={`/clients/edit/${client.id}`} // Kjo është rruga për të redaktuar klientin
          className="bg-gradient-to-r from-blue-500 to-blue-600 text-white px-4 py-2 rounded-lg shadow hover:shadow-md transition-transform transform hover:scale-105 mr-2"
        >
          Edit
        </Link>
        <button
          className="bg-gradient-to-r from-red-500 to-red-600 text-white px-4 py-2 rounded-lg shadow hover:shadow-md transition-transform transform hover:scale-105"
          onClick={() => deleteClient(client.id)}
        >
          Delete
        </button>
      </td>
    </tr>
  );
};

const ClientList = () => {
  const { clients, loading, error, deleteClient } = useClientContext();

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
    return (
      <div className="text-center text-red-500 text-lg mt-6">{error}</div>
    );

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
          Client List
        </h2>

        {/* Tabela */}
        <div className="overflow-x-auto shadow-xl rounded-lg bg-white/90">
          <table className="min-w-full border border-gray-300">
            <thead>
              <tr className="bg-gray-200 text-gray-800">
                <th className="py-3 px-4 text-left font-semibold">ID</th>
                <th className="py-3 px-4 text-left font-semibold">Name</th>
                <th className="py-3 px-4 text-left font-semibold">Email</th>
                <th className="py-3 px-4 text-left font-semibold">
                  Phone Number
                </th>
                <th className="py-3 px-4 text-left font-semibold">Created At</th>
                <th className="py-3 px-4 text-left font-semibold">Actions</th>
              </tr>
            </thead>
            <tbody>
              {clients.map((client) => (
                <TableRow
                  key={client.id}
                  client={client}
                  deleteClient={deleteClient}
                />
              ))}
            </tbody>
          </table>
        </div>

        {/* Butoni për krijimin e klientit */}
        <div className="text-center mt-6">
          <Link
            to="/create-client"
            className="bg-blue-500 hover:bg-blue-600 text-white px-6 py-2 rounded-full shadow transition"
          >
            Create New Client
          </Link>
        </div>
      </div>
    </div>
  );
};

export default ClientList;

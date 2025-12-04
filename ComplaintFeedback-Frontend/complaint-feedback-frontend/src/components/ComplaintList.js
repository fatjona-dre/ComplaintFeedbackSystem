import React, { useEffect, useState } from "react";
import api from "../services/api";

const ComplaintList = () => {
  const [complaints, setComplaints] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  useEffect(() => {
    fetchComplaints();
  }, []);

  const fetchComplaints = async () => {
    try {
      const response = await api.get("/ComplaintFeedback");
      setComplaints(response.data);
      setLoading(false);
    } catch (err) {
      console.error(err);
      setError("Diçka shkoi gabim gjatë marrjes së ankesa.");
      setLoading(false);
    }
  };

  if (loading) return <p>Duke ngarkuar ankesa...</p>;
  if (error) return <p style={{ color: "red" }}>{error}</p>;

  return (
    <div style={{ maxWidth: "800px", margin: "20px auto" }}>
      <h2>Lista e Ankesa</h2>
      <table style={{ width: "100%", borderCollapse: "collapse" }}>
        <thead>
          <tr>
            <th>ID</th>
            <th>Tipi</th>
            <th>Mesazhi</th>
            <th>Statusi</th>
            <th>Data</th>
          </tr>
        </thead>
        <tbody>
          {complaints.map((c) => (
            <tr key={c.id}>
              <td>{c.id}</td>
              <td>{c.type}</td>
              <td>{c.message}</td>
              <td>{c.status}</td>
              <td>{new Date(c.submittedAt).toLocaleString()}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ComplaintList;

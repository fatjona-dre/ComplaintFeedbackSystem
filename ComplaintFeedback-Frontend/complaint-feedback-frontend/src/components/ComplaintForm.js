import React, { useState } from "react";
import api from "../services/api";

const ComplaintForm = () => {
  // State për fushat e formës
  const [type, setType] = useState("");
  const [orderId, setOrderId] = useState("");
  const [message, setMessage] = useState("");
  const [status, setStatus] = useState(""); // për feedback përdoruesi
  const [successMessage, setSuccessMessage] = useState("");
  const [errorMessage, setErrorMessage] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();
    setSuccessMessage("");
    setErrorMessage("");

    // Validim i thjeshtë
    if (!type || !orderId || !message) {
      setErrorMessage("Ju lutem plotësoni të gjitha fushat.");
      return;
    }

    try {
      const response = await api.post("/ComplaintFeedback", {
        type,
        orderId: parseInt(orderId),
        message,
      });
      setSuccessMessage("Ankesa u dërgua me sukses!");
      setType("");
      setOrderId("");
      setMessage("");
    } catch (error) {
      console.error(error);
      setErrorMessage("Diçka shkoi gabim. Provo përsëri.");
    }
  };

  return (
    <div style={{ maxWidth: "500px", margin: "20px auto" }}>
      <h2>Dërgo Ankesa / Feedback</h2>
      {successMessage && <p style={{ color: "green" }}>{successMessage}</p>}
      {errorMessage && <p style={{ color: "red" }}>{errorMessage}</p>}
      <form onSubmit={handleSubmit}>
        <div>
          <label>Tipi i ankesa</label>
          <input
            type="text"
            value={type}
            onChange={(e) => setType(e.target.value)}
          />
        </div>
        <div>
          <label>Order ID</label>
          <input
            type="number"
            value={orderId}
            onChange={(e) => setOrderId(e.target.value)}
          />
        </div>
        <div>
          <label>Mesazhi</label>
          <textarea
            value={message}
            onChange={(e) => setMessage(e.target.value)}
          />
        </div>
        <button type="submit">Dërgo</button>
      </form>
    </div>
  );
};

export default ComplaintForm;

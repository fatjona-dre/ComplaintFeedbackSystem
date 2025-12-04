import React from "react";
import ComplaintForm from "./components/ComplaintForm";
import ComplaintList from "./components/ComplaintList";
import AdminPanel from "./components/AdminPanel";

function App() {
  return (
    <div>
      <h1>Platforma e Menaxhimit të Ankesa dhe Feedback</h1>
      <ComplaintForm />
      <ComplaintList />
      <AdminPanel />
    </div>
  );
}

export default App;
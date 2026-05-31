import { Routes, Route } from "react-router-dom";
import Orders from './pages/Orders';
import CreateOrder from './pages/CreateOrder';
import OrderDetails from "./pages/OrderDetails";

function App() {
  return (
    <Routes>
        <Route path="/" element={<Orders />} />
        <Route path="/orders/:id" element={<OrderDetails />} />
        <Route path="/create" element={<CreateOrder />} />
    </Routes>
  );
}

export default App
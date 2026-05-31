import { useNavigate, useParams } from "react-router-dom";
import type { Order } from "../types/order";
import { useEffect, useState } from "react";
import { orderService } from "../services/orderService";
import styles from "./OrderDetails.module.css";

export default function OrderDetails() {
    const navigate = useNavigate();
    const { id } = useParams();
    const [order, setOrder] = useState<Order | null>(null);

    useEffect(() => {
        loadOrder();
    }, []);

    async function loadOrder() {
        if (!id) return;

        const data = await orderService.getById(id);

        setOrder(data);
    }

    if (!order) {
        return <p>Carregando...</p>;
    }

    return (
        <div>
            <h1>Detalhes do Pedido</h1>
            <button onClick={() => navigate("/")}>
                Voltar para Pedidos
            </button>
            <p>
                <strong>Id do Pedido:</strong>
                {" "}
                {order.id}
            </p>
            <p>
                <strong>Cliente:</strong>
                {" "}
                {order.customerName}
            </p>
            <p>
                <strong>Valor Total:</strong>
                {" "}
                {order.total.toLocaleString("pt-BR", {
                    style: "currency",
                    currency: "BRL"
                })}
            </p>
            <p>
                <strong>Status:</strong>
                {" "}
                {order.status}
            </p>
            <p>
                <strong>Data do Pedido:</strong>
                {" "}
                {new Date(order.createdAt).toLocaleString("pt-BR")}
            </p>

            <h2>Itens do Pedido</h2>
            <table className={styles.table}>
                <thead>
                    <tr>
                        <th>Produto</th>
                        <th>Quantidade</th>
                        <th>Preço Unitário</th>
                        <th>Subtotal</th>
                    </tr>
                </thead>
                <tbody>
                    {order.items.map((item) => (
                        <tr key={item.id}>
                            <td>{item.productName}</td>
                            <td>{item.quantity}</td>
                            <td>{item.price.toLocaleString("pt-BR", {
                                style: "currency",
                                currency: "BRL"
                            })}</td>
                            <td>{(item.price * item.quantity).toLocaleString("pt-BR", {
                                style: "currency",
                                currency: "BRL"
                            })}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}
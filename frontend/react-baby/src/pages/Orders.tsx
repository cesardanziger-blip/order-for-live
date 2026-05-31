import { useEffect, useState } from "react";
import type { Order } from "../types/order";
import { orderService } from "../services/orderService";
import { useNavigate } from "react-router-dom";
import Layout from "../layouts/Layout";
import styles from "./Orders.module.css";

export default function Orders() {
    const navigate = useNavigate();
    const [orders, setOrders] = useState<Order[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        loadOrders();
    }, []);

    async function handleDelete(id: string) {
        const confirmDelete = confirm(
            "Deseja realmente excluir este pedido?"
        );

        if (!confirmDelete) {
            return;
        }

        try {
            await orderService.delete(id);

            setOrders(
                orders.filter(order => order.id !== id)
            );
        }
        catch (error) {
            console.error(error);
            alert("Erro ao excluir pedido");
        }
    }

    async function loadOrders() {
        try {
            const data = await orderService.getAll();
            setOrders(data);
        } catch (error) {
            console.error("Failed do Load Orders", error);
        } finally {
            setLoading(false);
        }
    }

    if (loading) {
        return <p>Carregando...</p>;
    }

    return (
        <Layout>
            <div>
                <h1>Pedidos</h1>

                <table className={styles.table}>
                    <thead>
                        <tr>
                            <th>Cliente</th>
                            <th>Total</th>
                            <th>Status</th>
                            <th>Data</th>
                            <th>Ações</th>
                        </tr>
                    </thead>
                    <tbody>
                        {orders.map((order) => (
                            <tr key={order.id}>
                                <td>{order.customerName}</td>
                                <td>{order.total.toLocaleString("pt-BR", {
                                    style: "currency",
                                    currency: "BRL"
                                })}</td>
                                <td>{order.status}</td>
                                <td>{new Date(order.createdAt).toLocaleString("pt-BR")}</td>
                                <td>
                                    <div className={styles.actions}>
                                        <button
                                            onClick={() => navigate(`/orders/${order.id}`)}                                            
                                        >
                                            Detalhes
                                        </button>
                                        <button
                                            onClick={() => handleDelete(order.id)}
                                        >
                                            Remover
                                        </button>
                                    </div>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </Layout>
    );
}
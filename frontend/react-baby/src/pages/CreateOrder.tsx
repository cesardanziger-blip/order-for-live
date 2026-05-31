import { useState } from "react";
import type { SubmitEventHandler } from 'react';
import { useNavigate } from "react-router-dom";
import { orderService } from "../services/orderService";
import type { CreateOrderItemRequest } from "../types/orderItem";
import Layout from "../layouts/Layout";
import styles from "./CreateOrder.module.css";

export default function CreateOrder() {
    const navigate = useNavigate();
    const [customerName, setCustomerName] = useState("");
    const [items, setItems] = useState<CreateOrderItemRequest[]>([
        {
            productName: "",
            quantity: 1,
            price: 0
        }
    ]);

    const handleSubmit: SubmitEventHandler<HTMLFormElement> = async (e) => {
        e.preventDefault();
        try {
            await orderService.create({
                customerName,
                items
            });

            navigate("/");
        }
        catch (error) {
            console.error(error);
            alert("Erro ao criar pedido");
        }
    }

    function addItem() {
        setItems([
            ...items,
            {
                productName: "",
                quantity: 1,
                price: 0
            }
        ]);
    }

    function removeItem(index: number) {
        setItems(items.filter((_, i) => i !== index));
    }

    function updateItem(
        index: number,
        field: string,
        value: string | number
    ) {
        const updated = [...items];

        updated[index] = {
            ...updated[index],
            [field]: value
        };

        setItems(updated);
    }

    return (
        <Layout>
            <div>
                <h1>Criar Pedido</h1>

                <form onSubmit={handleSubmit}>
                    <div>
                        <label className={styles.label}>Cliente</label>

                        <input
                            className={styles.input}
                            placeholder="Nome do cliente"
                            value={customerName}
                            onChange={(e) =>
                                setCustomerName(e.target.value)
                            }
                        />
                    </div>

                    <h2>Itens</h2>

                    {items.map((item, index) => (
                        <div key={index} className={styles.itemRow}>

                            <div className={styles.field}>
                                <label className={styles.label}>
                                    Produto
                                </label>

                                <input
                                    className={styles.input}
                                    value={item.productName}
                                    onChange={(e) =>
                                        updateItem(
                                            index,
                                            "productName",
                                            e.target.value
                                        )
                                    }
                                />
                            </div>

                            <div className={styles.field}>
                                <label className={styles.label}>
                                    Quantidade
                                </label>

                                <input
                                    className={styles.input}
                                    type="number"
                                    value={item.quantity}
                                    onChange={(e) =>
                                        updateItem(
                                            index,
                                            "quantity",
                                            Number(e.target.value)
                                        )
                                    }
                                />
                            </div>

                            <div className={styles.field}>
                                <label className={styles.label}>
                                    Preço
                                </label>

                                <input
                                    className={styles.input}
                                    type="number"
                                    value={item.price}
                                    onChange={(e) =>
                                        updateItem(
                                            index,
                                            "price",
                                            Number(e.target.value)
                                        )
                                    }
                                />
                            </div>

                            <button
                                type="button"
                                onClick={() => removeItem(index)}
                            >
                                Remover
                            </button>

                        </div>
                    ))}

                    <button
                        type="button"
                        onClick={addItem}
                    >
                        Adicionar Item
                    </button>

                    <button type="submit">
                        Salvar Pedido
                    </button>
                </form>
            </div>
        </Layout>
    );
}
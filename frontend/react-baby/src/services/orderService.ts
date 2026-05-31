import { api } from "../api/axios";
import type {Order, CreateOrderRequest } from "../types/order";

export const orderService = {
    async getAll(): Promise<Order[]> {
        const response = await api.get<Order[]>("/orders");
        return response.data;
    },

    async getById(id: string): Promise<Order> {
        const response = await api.get<Order>(`/orders/${id}`);
        return response.data;
    },

    async create(order: CreateOrderRequest): Promise<void> {
        await api.post("/orders", order);
    },

    async delete(id: string): Promise<void>{
        await api.delete(`/orders/${id}`);
    }
}
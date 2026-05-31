import type { CreateOrderItemRequest, OrderItem } from "./orderItem";
import type { Status } from "./status";

export interface Order{
    id: string;
    customerName: string;
    total: number;
    status: Status;
    createdAt: string;
    items: OrderItem[];
}

export interface CreateOrderRequest  {
  customerName: string;
  items: CreateOrderItemRequest[];
}
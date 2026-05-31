export interface OrderItem{
    id: string;
    productName: string;
    quantity: number;
    price: number;
    orderid: string;
}

export interface CreateOrderItemRequest  {
  productName: string;
  quantity: number;
  price: number;
}
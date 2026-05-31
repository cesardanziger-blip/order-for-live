export const OrderStatus ={
  Pending: 0,
  Approved: 1
} as const;

export type Status = keyof typeof OrderStatus;
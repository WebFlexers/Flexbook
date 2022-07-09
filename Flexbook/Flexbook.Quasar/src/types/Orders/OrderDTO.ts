import {OrderItemDTO} from 'src/types/Orders/OrderItemDTO';

export interface OrderDTO {
  paymentMethod: string,
  orderItemsList: OrderItemDTO[],
  customerId: number
}

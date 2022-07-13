import {api} from 'boot/axios';
import {OrderDTO} from 'src/types/Orders/OrderDTO';

export class OrderService {
  public async createOrder(order: OrderDTO) {
    const result = await api.post('customer/order/place_order', order)
    console.log(result.data)
    return result.data
  }
}

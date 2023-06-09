import React from 'react'
import OrderRow from '../OrderRow/OrderRow'
import cl from './OrderList.module.css'
import Loader from '../UI/Loader/Loader';

const OrdersList = ({orders, showOrderById}) => {

  if (!orders.length){
    return (
      <div className={cl.orderList}>
      <h2 className={cl.label}>Список заказов:</h2>
      <div className={cl.line}></div>
      <h3 className={cl.labelEmpty}>Список заказов пуст.</h3>
      
    </div>
    );
  }

  return (
    <div className={cl.orderList}>
      <h2 className={cl.label}>Список заказов:</h2>
      
        {orders.map(order=><OrderRow showOrderById={showOrderById} key={order.id} order={order}/>)}
    </div>
  )
}

export default OrdersList
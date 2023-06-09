import React from 'react'
import cl from './OrderRow.module.css'
import { dateCut } from '../../utils/date'

const OrderRow = ({order, showOrderById}) => {

  const showOrder = () => {
    showOrderById(order.id);
  }

  return (
    <div className={cl.orderRow} onClick={showOrder}>
        <div className={cl.orderRowItem}>{order.id}</div>
        <div className={cl.orderRowItem}>{order.senderСity}</div>
        <div className={cl.orderRowItem}>{order.senderAddres}</div>
        <div className={cl.orderRowItem}>{order.recipientCity}</div>
        <div className={cl.orderRowItem}>{order.recipientAddres}</div>
        <div className={cl.orderRowItem}>{order.weightCargo}</div>
        <div className={cl.orderRowItem}>{ dateCut(order.pickupDate)}</div>
    </div>
  )
}

export default OrderRow
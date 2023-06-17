import React from 'react'
import { dateCut } from '../../utils/date'

const ShowOrder = ({title,order}) => {
  return (
    <div className='ShowOrder'>
      <h2>{title}</h2>
        <div>Город отправителя: <b>{order.senderСity}</b></div>
        <div>Адрес отправителя: <b>{order.senderAddres}</b></div>
        <div>Город получателя: <b>{order.recipientCity}</b></div>
        <div>Адрес получателя: <b>{order.recipientAddres}</b></div>
        <div>Вес груза: <b>{order.weightCargo}</b></div>
        <div>Дата забора груза: <b>{dateCut(order.pickupDate)}</b></div>
    </div>
  )
}

export default ShowOrder
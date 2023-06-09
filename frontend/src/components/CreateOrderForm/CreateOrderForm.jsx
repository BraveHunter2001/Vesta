import React, { useEffect, useState } from 'react'
import Button from '../UI/Button/Button';
import Input from '../UI/input/Input';
import cl from './CreateOrderForm.module.css'

const CreateOrderForm = ({create}) => {

    const [orderCreated, setOrderCreated] = useState({
        pickupDate: '',
        recipientAddres:'',
        recipientCity:'',
        senderAddres:'',
        senderСity:'',
        weightCargo:0,
    });

    const [isValid, setIsValid] = useState(true)
    const [isDisabled, setIsDisabled] = useState(true)

    useEffect(()=>{
        if (orderCreated.weightCargo < 0)
            setIsValid(false);
        else
            setIsValid(true);

    },[orderCreated.weightCargo])


    useEffect(()=>{
        if (!orderCreated.pickupDate 
            || !orderCreated.recipientAddres 
            || !orderCreated.recipientCity 
            || !orderCreated.senderAddres 
            || !orderCreated.senderСity
            || !orderCreated.weightCargo) {
                setIsDisabled(true);
        } else setIsDisabled(false);
    },[orderCreated])

    const createOrder = (e) => {


        e.preventDefault()

        create(orderCreated)
    }
  return (
    <div className={cl.orderoForm}>
        <h2>Создание заказа</h2>
        <form>
            <Input  
                onChange={e => setOrderCreated({...orderCreated,senderСity:e.target.value})} 
                value={orderCreated.senderСity} 
                placeholder='Город отправителя' />
            <Input  
                onChange={e => setOrderCreated({...orderCreated,senderAddres:e.target.value})}
                value={orderCreated.senderAddres} 
                placeholder='Адрес отправителя' />
            <Input  
                onChange={e => setOrderCreated({...orderCreated,recipientCity:e.target.value})}
                value={orderCreated.recipientCity}
                placeholder='Город получателя'/>
            <Input  
                onChange={e => setOrderCreated({...orderCreated,recipientAddres:e.target.value})} 
                value={orderCreated.recipientAddres} 
                placeholder='Адрес получателя'/>
            <Input  
                onChange={e => setOrderCreated({...orderCreated,weightCargo:e.target.value})}
                value={orderCreated.weightCargo} 
                type='number'
                min='0'
                placeholder='Вес посылки'/>
            <Input  
                onChange={e => setOrderCreated({...orderCreated,pickupDate:e.target.value.toString()})}
                value={orderCreated.pickupDate}
                type="date" placeholder='Дата отправки'/>
            <div className={cl.botBox}>
                <Button disabled={isDisabled} onClick={createOrder}>Создать заказ</Button>
                {!isValid&& <div className={cl.errorInfo}> Неверно введенные данные</div>}
            </div>
          
        </form>
    </div>
  )
}

export default CreateOrderForm
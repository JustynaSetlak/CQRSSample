import React from 'react';

export const productListColumns = [
    {
      title: 'Name',
      dataIndex: 'name',
      render: text => <a>{text}</a>,
    },
    {
      title: 'Age',
      dataIndex: 'age',
    },
    {
      title: 'Description',
      dataIndex: 'description',
    },
  ];

export const baseUrl = "http://localhost:53496/";
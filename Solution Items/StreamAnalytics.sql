-- �N��ƱqIoT Hub�g�J�ܸ�Ʈw
SELECT
    DeviceId, Temperature, Humidity, PM25, SendDateTime
INTO
    [ToDb]
FROM
    [FromIoT]
    
-- �N��ƱqIoT Hub�g�J���x�s��
SELECT
    *
INTO
    [ToStorage]
FROM
    [FromIoT]
    
-- �N��ƱqIoT Hub�g�J�ܪA�ȶ׬y�Ʀ�C
SELECT
    DeviceId, Temperature, Humidity, PM25, SendDateTime
INTO
    [ToServiceBus]
FROM
    [FromIoT]

SELECT
    DeviceId, Temperature, Humidity, PM25, SendDateTime as time
INTO
    [ToPowerBI]
FROM
    [FromIoT]
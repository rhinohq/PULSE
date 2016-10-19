from __future__ import unicode_literals

from django.db import models

class Client(models.Model):
    public_token = models.CharField(max_length=24)
    private_token = models.CharField(max_length=7)
    name = models.CharField(max_length=None)
    playerid = models.CharField(max_length=30)

class Device(models.Model):
    public_token = models.CharField(max_length=24)
    private_token = models.CharField(max_length=7)
    name = models.CharField(max_length=None)
    address = models.GenericIPAddressField()
